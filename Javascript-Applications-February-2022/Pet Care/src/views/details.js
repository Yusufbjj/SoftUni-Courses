import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as petsService from '../api/pets.js';

const detailsTemplate = (pet, onDelete) => html`
    <!--Details Page-->
    
    <!--Details Page-->
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: 0</h4>
                </div>
   
                ${pet.isOwner
                ? html`
                <div class="actionBtn">
                    <!-- Only for registered user and creator of the pets-->
                    <a href="/edit/${pet._id}" class="button">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                </div>`
                // <!--(Bonus Part) Only for no creator and user-->
    
                // <!-- <a href="#" class="donate">Donate</a> --> 
                : nothing}
                <!-- if there is no registered user, do not display div-->
            </div>
        </div>
    </section>

`;

export async function detailsPage(ctx) {

    
    const petId = ctx.params.id;

    const pet = await petsService.getById(petId);

    if (ctx.user) {
        
        pet.isOwner = ctx.user._id == pet._ownerId;

    }

    ctx.render(detailsTemplate(pet, onDelete));

    async function onDelete() {

        const choice = confirm(`Are you sure you want to delete ${pet.name}?`);

        if (choice) {
            await petsService.deleteById(petId);
            ctx.page.redirect('/');
        }
    }

};