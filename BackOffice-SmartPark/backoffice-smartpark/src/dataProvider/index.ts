import { DataProvider, fetchUtils } from "react-admin";
import { stringify } from "query-string";

const apiUrls = {
  pagamentos: "http://localhost:5003/v1",
  vagas: "http://localhost:5001/v1",
};

const httpClient = (url: string, options: fetchUtils.Options = {}) => {
  if (!options.headers) {
    options.headers = new Headers({ Accept: "application/json" });
  }
  const token = localStorage.getItem("token");
  options.headers.set("Authorization", `Bearer ${token}`);
  return fetchUtils.fetchJson(url, options);
};

const getApiUrl = (resource: string) => apiUrls[resource] || apiUrls.pagamentos;

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

    const apiUrl = getApiUrl(resource);
    const url = `${apiUrl}/${resource}?${queryParams.toString()}`;

    const { headers, json } = await httpClient(url);

    let data = [];
    if (resource === "pagamentos") {
      data = Array.isArray(json.pagamentos) ? json.pagamentos : [];
    } else if (resource === "vagas") {
      data = Array.isArray(json.vagas) ? json.vagas : [];
    } else {
      data = Array.isArray(json.data) ? json.data : [];
    }

    return {
      data,
      total: json.totalRecords || data.length,
    };
  },

  getOne: async (resource, params) => {
    const apiUrl = getApiUrl(resource);
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
    const apiUrl = getApiUrl(resource);
    const url = `${apiUrl}/${resource}?${stringify(query)}`;
    const { json } = await httpClient(url);
    return {
      data: json,
    };
  },

  create: async (resource, params) => {
    const apiUrl = getApiUrl(resource);
    const url = `${apiUrl}/${resource}`;
    const { json } = await httpClient(url, {
      method: "POST",
      body: JSON.stringify(params.data),
    });

    return {
      data: { ...params.data, id: json.id },
    };
  },

  update: async (resource, params) => {
    const apiUrl = getApiUrl(resource);
    const url = `${apiUrl}/${resource}`;
    const { status, json } = await httpClient(url, {
      method: "PUT",
      body: JSON.stringify(params.data),
    });
    if (status === 204) {
      return { data: { ...params.data, id: params.id } };
    }
    return { data: json };
  },

  delete: async (resource, params) => {
    const apiUrl = getApiUrl(resource);
    const url = `${apiUrl}/${resource}/${params.id}`;
    const { json } = await httpClient(url, {
      method: "DELETE",
    });
    return {
      data: json,
    };
  },
};

export default dataProvider;
