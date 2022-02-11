function add(n) {

    let sum = 0;

    function inner(num) {

        sum += num;

        return inner;

    }

    inner.toString = () => {

        return sum;

    }

    return inner(n);

}
console.log(add(1)(6)(-3).toString());
