import { render, html } from '../../node_modules/lit-html/lit-html.js';

const navTemplate = (user) => html`
<nav>
    <section class="logo">
        <img src="./images/logo.png" alt="logo">
    </section>
    <ul>
        <!--Users and Guest-->
        <li><a href="/">Home</a></li>
        <li><a href="/catalog">Dashboard</a></li>
        <!--Only Guest-->
        ${user
        ? html`
        <li><a href="/create">Create Postcard</a></li>
        <li><a href="/logout">Logout</a></li> `
        : html`
        <li><a href="/login">Login</a></li>
        <li><a href="/register">Register</a></li>
        `}
        <!--Only Users-->
    </ul>
</nav>

`;
// ref for the header
const header = document.querySelector('.my-header');

// refference for the current view
const root = document.getElementById('main-content');

//render view
function ctxRender(content) {
    render(content, root);
};

//adding ctxRender function as a property to the ctx and invoke next()
export function addRender(ctx, next) {

    render(navTemplate(ctx.user), header)

    ctx.render = ctxRender;

    next();
}