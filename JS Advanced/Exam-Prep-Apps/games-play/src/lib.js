import { html, render } from "/../node_modules/lit-html/lit-html.js";  

import page from "../node_modules/page/page.mjs";

import { getUserData, clearUserData, setUserData } from "./services/util.js";

import { login, logout, register, getAll, getById, deleteById, create, edit, getMostRecentlyAddedGames, getComments, commentGame } from "./services/data.js";

export {
    html,
    render,
    page,

    getUserData,
    clearUserData,
    setUserData,

    logout,
    login,
    register,

    getAll,
    getById,
    deleteById,
    create,
    edit,
    getMostRecentlyAddedGames,
    getComments,
    commentGame
};
