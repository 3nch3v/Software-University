function solve(...args) {
    let counter = new Map();

    args.forEach(a => {
        let type = typeof a;
        if(!counter.has(type)) {
            counter.set(type, 0);
        }
        counter.set(type, (counter.get(type) + 1));

        console.log(`${type}: ${a}`);
    })

    counter = new Map([...counter.entries()].sort((a, b) => b[1] - a[1]));

    for (let [key, value] of counter) {
        console.log(`${key} = ${value}`);
    }
};

console.log(solve('cat', 42, function () { console.log('Hello world!'); }, 'dog'));

