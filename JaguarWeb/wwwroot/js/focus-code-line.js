/* *******************************
 * Stylize the anchored code line
 * ******************************/
function focusCodeLine(id) {
    const line = document.getElementById("line-" + id);
    if (line === null) {
        throw Error("Couldn't find element with id '" + id +"'.");
    }

    const parent = line.parentElement
    parent.id = "focusedLineParent";

    const sign = document.createElement("figure");
    sign.id = "focusedLine";

    parent.prepend(sign);

    setTimeout(()=> {document.getElementById("line-" + id).scrollIntoView();}, 500);
}