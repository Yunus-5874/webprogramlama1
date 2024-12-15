// Log verilerini simüle eden bir JSON array
const logs = [
    { timestamp: "2024-12-08 12:00:00", level: "INFO", message: "Başarılı giriş" },
    { timestamp: "2024-12-08 12:05:00", level: "ERROR", message: "Hatalı şifre denemesi" },
    { timestamp: "2024-12-08 12:10:00", level: "WARNING", message: "Düşük bellek uyarısı" }
];

// Tabloyu dolduracak fonksiyon
function populateTable() {
    const tableBody = document.querySelector("#logTable tbody");
    logs.forEach(log => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${log.timestamp}</td>
            <td>${log.level}</td>
            <td>${log.message}</td>
        `;
        tableBody.appendChild(row);
    });
}

// Sayfa yüklendiğinde tabloyu doldur
document.addEventListener("DOMContentLoaded", populateTable);
