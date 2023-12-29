        /** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["*.razor", "./Pages/**/*.{html,js,cshtml,razor}", "./Shared/**/*.{html,js,cshtml,razor}", "./Components/**/*.{html,js,cshtml,razor}"],
    safelist: [
        'bg-red-500',
        'text-3xl',
        'lg:text-4xl',
    ],
    plugins: [],
    theme: {
        extend: {
            width: {
                '128': '32rem',
            }
        },
    },
}