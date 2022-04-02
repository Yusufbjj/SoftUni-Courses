//returns the user object
export function getUserData() {
    return JSON.parse(localStorage.getItem('user'));
}

//returns only the access token
export function getAccessToken() {
    const user = getUserData();

    if (user) {
        return user.accessToken;
    } else {
        return null;
    }
}

//delete user from local storage,invoke when logging out
export function clearUserData() {
    localStorage.removeItem('user');
}

//save user to local storage ,invoke it when login in and register 
export function setUserData(data) {
    localStorage.setItem('user', JSON.stringify(data));
}

//removes the boiler plate from the different forms , decorator function
export function createSubmitHandler(ctx, handler) {
    return function (event) {
        event.preventDefault();
        const formData = Object.fromEntries(new FormData(event.target));

        handler(ctx,formData,event);
    };
}