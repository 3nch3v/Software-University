export async function request(url, method, obj, authorizationToken, emptyResponse) {
    const body = JSON.stringify(obj);
    
    const options = {
        method: `${method}`,
        headers: {}
    }
    
    if(method.toUpperCase() === 'POST' 
      || method.toUpperCase() === 'PUT') {
          
        options.headers['Content-Type'] = 'application/json' ;

        if(body == null) {
            throw new Error(`The request body is empty.`);
        }

        options.headers['Content-Length'] = body.length ;
        options.body = body
    }

    if(authorizationToken != undefined) {
        options.headers['X-Authorization'] = authorizationToken;
    }

    const res = await fetch(url, options)
    console.log(res);
    if(res.ok !== true) {
        const error = await res.json();
        throw new Error(error.message);
    }

    if(emptyResponse) {
        return res.status == 204 ? true : false;
    }

    return await res.json();
}