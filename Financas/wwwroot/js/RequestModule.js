export default function request(url = "", Method = "", data) {
    let response = fetch(url, {
        method: Method,
        credetials: "include",
        headers: {
            "Content-Type": "application/json"
        },
        redirect: "manual",
        body: JSON.stringify(data)
    })
    return response.then()
}