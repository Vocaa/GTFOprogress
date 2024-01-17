async function renderToClipboard() {
    // Step 1: Capture the Element
    const element = document.getElementById('capture');
    if (!element) {
        console.error('Element with id "capture" not found.');
        return;
    }

    // Step 2: Convert Element to HTML String
    const htmlString = element.outerHTML;

    // Step 3: Render HTML to Canvas
    const canvas = document.createElement('canvas');
    rasterizeHTML.drawHTML(htmlString, canvas)
        .then(renderResult => {
            // Step 4: Convert Canvas to Image
            const imageData = canvas.toDataURL('image/png');

            // Step 5: Copy Image to Clipboard
            fetch(imageData)
                .then(res => res.blob())
                .then(blob => {
                    const item = new ClipboardItem({ "image/png": blob });
                    navigator.clipboard.write([item])
                        .then(() => console.log('Image copied to clipboard!'))
                        .catch(err => console.error('Failed to copy image to clipboard:', err));
                });
        })
        .catch(error => {
            console.error('Error rendering:', error);
        });
}