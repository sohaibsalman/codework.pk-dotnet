import http from "./httpService";

import { apiUrl } from "../config.json";

export function login(controller, username, password) {
  const apiEndpoint = apiUrl + `/${controller}` + "/login";
  return http.post(apiEndpoint, { username, password });
}
