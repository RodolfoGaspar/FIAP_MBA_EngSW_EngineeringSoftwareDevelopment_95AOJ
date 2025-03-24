import { DataProvider, fetchUtils } from "react-admin";
import { stringify } from "query-string";

// Defina a URL base da sua API
const apiUrl = import.meta.env.VITE_API_INTEGRACOES_URL;

const httpClient = (url: string, options: fetchUtils.Options = {}) => {
  if (!options.headers) {
    options.headers = new Headers({ Accept: "application/json" });
  }
  const token = localStorage.getItem("token");
  options.headers.set("Authorization", `Bearer ${token}`);
  return fetchUtils.fetchJson(url, options);
};

const dataProvider: DataProvider = {
  getList: async (resource, params) => {
    const { page, perPage } = params.pagination!;
    const { filter } = params;

    const queryParams = new URLSearchParams({
      offset: String(page),
      limit: String(perPage),
    });

    if (filter) {
      Object.keys(filter).forEach((key) => {
        if (filter[key] !== undefined && filter[key] !== "") {
          queryParams.append(key, filter[key]);
        }
      });
    }

    const url = `${apiUrl}/${resource}?${queryParams.toString()}`;

    const { headers, json } = await httpClient(url);
    return {
      total: json.totalRecords,
      pageInfo: {
        limit: json.limit,
        offset: json.offset,
      },
      data: json.data,
    };
  },

  getOne: async (resource, params) => {
    const url = `${apiUrl}/${resource}/${params.id}`;
    const { json } = await httpClient(url);
    return {
      data: json,
    };
  },

  getMany: async (resource, params) => {
    const query = {
      filter: JSON.stringify({ id: params.ids }),
    };
    const url = `${apiUrl}/${resource}?${stringify(query)}`;
    const { json } = await httpClient(url);
    return {
      data: json,
    };
  },

  getManyReference: async (resource, params) => {
    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;
    const query = {
      sort: JSON.stringify([field, order]),
      range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
      filter: JSON.stringify({
        ...params.filter,
        [params.target]: params.id,
      }),
    };
    const url = `${apiUrl}/${resource}?${stringify(query)}`;
    const { headers, json } = await httpClient(url);
    return {
      data: json,
      total: parseInt(
        headers.get("content-range")?.split("/").pop() || "0",
        10,
      ),
    };
  },

  update: async (resource, params) => {
    const url = `${apiUrl}/${resource}/${params.id}`;
    const { status, json } = await httpClient(url, {
      method: "PUT",
      body: JSON.stringify(params.data),
    });
    if (status === 204) {
      return { data: { ...params.data, id: params.id } };
    }
    return { data: json };
  },

  updateMany: async (resource, params) => {
    const responses = await Promise.all(
      params.ids.map((id) =>
        httpClient(`${apiUrl}/${resource}/${id}`, {
          method: "PUT",
          body: JSON.stringify(params.data),
        }),
      ),
    );
    return {
      data: responses.map(({ json }) => json.id),
    };
  },

  create: async (resource, params) => {
    const url = `${apiUrl}/${resource}`;
    const { json } = await httpClient(url, {
      method: "POST",
      body: JSON.stringify(params.data),
    });
    // Ensure the response includes the 'id' field
    if (!json.cd_tb_integracao) {
      throw new Error("Resposta da API não inclui um id");
    }

    return {
      data: { ...params.data, id: json.cd_tb_integracao },
    };
  },

  delete: async (resource, params) => {
    const url = `${apiUrl}/${resource}/${params.id}`;
    const { json } = await httpClient(url, {
      method: "DELETE",
    });
    return {
      data: json,
    };
  },

  deleteMany: async (resource, params) => {
    const responses = await Promise.all(
      params.ids.map((id) =>
        httpClient(`${apiUrl}/${resource}/${id}`, {
          method: "DELETE",
        }),
      ),
    );
    return {
      data: responses.map(({ json }) => json.id),
    };
  },
};

export default dataProvider;
