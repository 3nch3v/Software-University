export async function request(url, obj, authorizationToken) {

    const body = JSON.stringify(obj);
    
    const options = {
        method: 'POST',
        headers: { 
            'Content-Type': 'application/json',
            'Content-Length': body.length 
        },
        body: body
    }
    
    if(authorizationToken != undefined) {
        options.headers['X-Authorization'] = authorizationToken;
    }

    const res = await fetch(url, options)

    if(res.ok !== true) {
        const error = await res.json();
        throw new Error(error.message);
    }

    return await res.json();
}