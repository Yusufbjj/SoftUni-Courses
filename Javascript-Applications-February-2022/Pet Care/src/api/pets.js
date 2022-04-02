import * as api from './api.js';

const endpoints = {
    recent: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    pets: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/pets',
    byId: '/data/pets/',
    deleteById: '/data/pets/',
    update: '/data/pets/',
    donate:'/data/donation'
};


export async function getRecent() {
    return api.get(endpoints.recent);
}

export async function getAll() {
    return api.get(endpoints.pets);
}

export async function getById(id) {

    return api.get(endpoints.byId + id);
}

export async function create(data) {

    return api.post(endpoints.create, data);
}

export async function update(id, data) {
    return api.put(endpoints.update + id, data)
}

export async function deleteById(id) {

    return api.del(endpoints.deleteById + id);
}

