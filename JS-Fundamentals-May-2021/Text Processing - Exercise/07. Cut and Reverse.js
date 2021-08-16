function cutReverse(input) {
    let middle = input.length/2;
    let first =input.substring(0,middle).split("").reverse().join("");
    let second = input.substring(middle).split("").reverse().join("");
    console.log(first);
    console.log(second);
}
cutReverse('tluciffiDsIsihTgnizamAoSsIsihT')
cutReverse('sihToDtnaCuoYteBIboJsihTtAdooGoSmI')