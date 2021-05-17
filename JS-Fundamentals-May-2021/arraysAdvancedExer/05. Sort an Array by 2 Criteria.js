function sortByTwoCriteria(array) {
    array.sort((a,b)=>a.localeCompare(b));
    array.sort((a,b)=>a.length-b.length);
        console.log(array.join("\n"));
}
sortByTwoCriteria(["alpha", "beta", "gamma"]);
sortByTwoCriteria(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
sortByTwoCriteria(["test", "Deny", "omen", "Default"]);