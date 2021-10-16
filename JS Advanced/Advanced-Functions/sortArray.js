function solve(arr, sortBy) {
    return sortBy === 'asc' ? arr.sort((a, b) => a - b) 
                            : arr.sort((a, b) => b - a);
}