import { displayItem } from './functions.js';
import { displayPaginateButton } from './pagination.js';
import { getElement } from './displayItems.js'

$(document).ready(() => {
    let pagina;
    if (localStorage.getItem("msg")) {
        $("main").prepend(localStorage.getItem("msg"));
        localStorage.clear();
    }
    axios.get(`http://localhost:5000/api/item?&pagina=1&itens=5`)
        .then(resp => {
            let items = resp.data;
            let pagination_info = JSON.parse(resp.headers.paginacao);
            pagina = pagination_info.pagina;
            console.log(pagination_info.pagina);
            items.forEach(item => displayItem(item));
            displayPaginateButton(pagination_info);
            getElement("#pre", "", `http://localhost:5000/api/item?&pagina=${pagination_info.pagina - 1}&itens=5`);
            getElement("#pos", "", `http://localhost:5000/api/item?&pagina=${pagination_info.pagina + 1}&itens=5`);
        })
        .catch(err => console.log(err));
});

