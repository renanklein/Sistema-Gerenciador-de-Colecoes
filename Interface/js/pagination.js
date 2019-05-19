export function displayPaginateButton(pagination_info) {
    let pagination_button = `<ul class="pagination">`;

    if (pagination_info["anterior"].localeCompare("Nao") == 0) {
        pagination_button = pagination_button.concat('<li class="page-item disabled"><a class="page-link" id="pre" href="#">&laquo;</a></li>');
    } else {
        pagination_button = pagination_button.concat('<li class="page-item"><a class="page-link" id="pre" href="#">&laquo;</a></li>');
    }

    for (let i = 1; i <= pagination_info.total; i++) {
        if (i === pagination_info["pagina"]) {
            pagination_button = pagination_button.concat(`<li  class="page-item active"><a class="page-link" id="${i}" href="#">${i}</a></li>`);
        }
        else {
            pagination_button = pagination_button.concat(`<li class="page-item disabled" ><a class="page-link" id="${i}"  href="#">${i}</a></li>`);
        }
    }

    if (pagination_info["proximo"].localeCompare("Nao") == 0) {
        pagination_button = pagination_button.concat('<li class="page-item disabled"><a class="page-link" id="pos" href="#">&raquo;</a></li>');
    }
    else {
        pagination_button = pagination_button.concat('<li id="pos" class="page-item"><a class="page-link" id="pos" href="#">&raquo;</a></li>');
    }

    pagination_button = pagination_button.concat("</ul>");
    $("#pagButton").append(pagination_button);
}

