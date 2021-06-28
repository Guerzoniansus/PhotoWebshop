/**
 * Goes to the product page.
 * @param {any} productTitle - The title of the product that was clicked on.
 */
function goToProduct(productTitle) {
    window.location.href = "/product?productTitle=" + productTitle;
}