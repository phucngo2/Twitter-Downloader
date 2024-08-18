import axiosLib from "axios";

const axios = axiosLib.create({
  baseURL: import.meta.env.VITE_API_URL,
});

axios.interceptors.response.use(undefined, (error) => {
  throw new Error(error?.response?.data?.message);
});

export { axios };
