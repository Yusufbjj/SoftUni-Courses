import page from '../node_modules/page/page.mjs';

//middlewares
import { addSession } from './middlewares/session.js';
import { addRender } from './middlewares/render.js';

//api functions
import { logout } from './api/user.js';

//views
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

//use this code to test the requests from the different services
import * as api from './api/games.js';
window.api = api;
page(addSession);

// global middleware 
page(addRender);

// Implement rendering dependency injection and create placeholder views
page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/logout', onLogout);

page.start();

function onLogout(ctx) {
    logout();
    debugger
    ctx.page.redirect('/');
}

