export async function request(url, method, obj) {
    const body = JSON.stringify(obj);
    
    const options = {
        method: `${method}`,
        headers: {},
    }
    
    if(method.toUpperCase() === 'POST') {
        options.headers['Content-Type'] = 'application/json' ;

        if(body == null) {
            throw new Error(`The request body is empty.`);
        }

        options.headers['Content-Length'] = body.length ;
        options.body = body
    }

    const res = await fetch(url, options)

    if(res.ok !== true) {
        const error = await res.json();
        throw new Error(error.message);
    }

    return await res.json();
}