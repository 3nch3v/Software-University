import * as api from "../api/api.js";
import { getUserData } from "./util.js";

const host = "http://localhost:3030";
api.settings.host = host;

const router = {
    all: '/data/games?sortBy=_createdOn%20desc', 
    games: '/data/games',
    byId: (id) => `/data/games/${id}`,
    mostRecentlyAddedGames: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    commentsByGameId: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
    comment: '/data/comments'
};


export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAll() {
    return await api.get(router.all);
}

export async function create(data) {
    return await api.post(router.games, data);
}

export async function edit(id, data) {
    return await api.put(router.byId(id), data);
}

export async function deleteById(id) {
    return await api.del(router.byId(id));
}

export async function getById(id) {
    return await api.get(router.byId(id));
}

export async function getComments(id) {
    return await api.get(router.commentsByGameId(id));
}

export async function getMostRecentlyAddedGames() {
    return await api.get(router.mostRecentlyAddedGames);
}

export async function commentGame(data) {
    return await api.post(router.comment, data);
}