import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7227/api", // vendos URL të backend-it tënd
});

export default api;
