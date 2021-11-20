export function getUser() {
    const user = sessionStorage.getItem('userData');
    return JSON.parse(user);
}

export function getUserId() {
    const user = getUser();

    if (!user) {
        return null;   
    }

    return user.id;
}

export function getUserToken() {
    const user = getUser();
    
    if (!user) {
        return null;   
    }

    return user.token;
}

export function getUserEmail() {
    const user = getUser();
       
    if (!user) {
        return null;   
    }
    return user.email;
}