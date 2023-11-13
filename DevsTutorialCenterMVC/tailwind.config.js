const defaultTheme = require("tailwindcss/defaultTheme");

module.exports = {
    content: [
        "./Pages/**/*.cshtml",
        "./Views/**/*.cshtml"
    ],
    theme: {
        fontFamily: {
            sans: ["Inter", ...defaultTheme.fontFamily.sans],
        },
        extend: {},
    },
    plugins: [],
}

