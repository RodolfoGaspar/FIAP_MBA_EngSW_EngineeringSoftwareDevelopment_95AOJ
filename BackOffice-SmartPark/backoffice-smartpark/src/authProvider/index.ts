import { AuthProvider } from "react-admin";
// import { login } from "../api/login";
// import { isJwtValid } from "../utils/isJwtValid";
// import { getUser } from "../api/getUser";

const authProvider: AuthProvider = {
  login: async ({ username, password }) => {
    try {
      const user = await login(username, password);
      localStorage.setItem("token", user.data);
      return Promise.resolve();
    } catch (error) {
      return Promise.reject(error);
    }
  },
  logout: async () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
  },
  checkAuth: async () => {
    const token = localStorage.getItem("token");
    if (isJwtValid(token)) return Promise.resolve();
    else {
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      return Promise.reject();
    }
  },
  checkError: async (error) => {
    if (error.status === 401 || error.status === 403) {
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      return Promise.reject();
    }
    return Promise.resolve();
  },
  getPermissions: async () => Promise.resolve(),
  getIdentity: async () => {
    const user = await getUser();

    return {
      id: user.sub,
      fullName: user.preferred_username,
    };
  },
};

export default authProvider;
