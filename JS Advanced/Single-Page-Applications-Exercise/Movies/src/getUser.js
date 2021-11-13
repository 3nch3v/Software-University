export function getUser() {
    const userData = JSON.parse(sessionStorage.getItem('userData'))
    
    return userData;
}