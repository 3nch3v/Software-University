import * as api from '../api/api.js';
import { getUserId } from '../lib.js';

const host = 'http://localhost:3030';
api.settings.host = host;

const router = {
    catalog: host + '/data/catalog',
    byId: (id) => `${host}/data/catalog/${id}`,
    byUserId: (userId) => `${host}/data/catalog?where=_ownerId%3D%22${userId}%22`
}

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAll() {
    return await api.get(router.catalog);
}

export async function getById(id) {
    return await api.get(router.byId(id));
}

export async function getByUser() {
    const userId = getUserId();
    return await api.get(router.byUserId(userId));
}

export async function create(data) {
    return await api.post(router.catalog, data);
}

export async function editById(id, data) {
    return await api.put(router.byId(id), data);
}

export async function deleteById(id) {
    return await api.del(router.byId(id));
}