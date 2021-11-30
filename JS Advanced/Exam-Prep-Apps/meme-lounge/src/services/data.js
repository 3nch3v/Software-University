import * as api from "../api/api.js";
import { getUserData } from "./util.js";

const host = "http://localhost:3030";
api.settings.host = host;

const router = {
    all: '/data/memes?sortBy=_createdOn%20desc',
    memes: '/data/memes',
    byId: (id) => `/data/memes/${id}`,
    getMemesByUserId: (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
};


export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAll() {
    return await api.get(router.all);
}

export async function getById(id) {
    return await api.get(router.byId(id));
}

export async function deleteById(id) {
  return await api.del(router.byId(id));
}

export async function create(data) {
    return await api.post(router.memes, data);
}

export async function edit(id, data) {
    return await api.put(router.byId(id), data);
}

export async function getByUserId() {
    const userData = getUserData();
    return await api.get(router.getMemesByUserId(userData.id));
}