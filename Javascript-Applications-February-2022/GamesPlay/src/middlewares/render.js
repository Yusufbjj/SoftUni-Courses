import { render, html } from '../../node_modules/lit-html/lit-html.js';

const navTemplate = (user) => html`
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
        <a href="/catalog">All games</a>
        ${user

        ? html`
    
        <div id="user">
            <a href="/create">Create Game</a>
            <a href="/logout">Logout</a>
        </div>`

        : html`
    
        <div id="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>`}
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