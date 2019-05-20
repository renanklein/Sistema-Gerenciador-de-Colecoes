export function displayItem(item) {
    let html = `<tr>
                    <td>${item.tipo}</td>
                    <td>${item.nome}</td>
                    <td>${item.categoria}</td>
                    <td>${item.autor}</td>
                    <td>${item.status}</td>
                    `;
    let dropdown_menu = `<td>
                        <div class="dropdown m-2">
                        <button class="btn btn-outline-dark dropdown-toggle" type="button" id="botaoMenu" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">Opções</button>
                            <div class="dropdown-menu" aria-labelledby="botaoMenu">
                                <a href="html/alterar.html?id=${item.itemId}" class="dropdown-item" id="op_alter">Alterar</a>
                                <a href="html/excluir.html?id=${item.itemId}" class="dropdown-item" id="op_exclu">Excluir</a>`;

    if (item.status.localeCompare("Disponivel") === 0) {
        dropdown_menu = dropdown_menu.concat(
            `<a href="html/emprestar.html?id=${item.itemId}" class="dropdown-item" id="op_emp">Emprestar</a></div></div></td></tr>`
        );
    }
    else{
        dropdown_menu = dropdown_menu.concat(
            `<a href="html/devolver.html?id=${item.itemId}" class="dropdown-item" id="op_dev">Devolver</a></div></div></td></tr>`
        );
    }
    html = html.concat(dropdown_menu);
    $('table').append("<tr>").append(html).hide().fadeIn(500);
}