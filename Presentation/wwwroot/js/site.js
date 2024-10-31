document.getElementById('registerEntryButton').addEventListener('click', async () => {
    const employeeId = document.getElementById('employeeId').value;
    const location = document.getElementById('location').value;

    const response = await fetch('/api/attendance/register-entry', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ employeeId, location }),
    });

    const message = response.ok ? 'Giriş kaydedildi.' : 'Giriş kaydetme hatası.';
    document.getElementById('message').innerText = message;
});

document.getElementById('registerExitButton').addEventListener('click', async () => {
    const employeeId = document.getElementById('employeeId').value;

    const response = await fetch('/api/attendance/register-exit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ employeeId }),
    });

    const message = response.ok ? 'Çıkış kaydedildi.' : 'Çıkış kaydetme hatası.';
    document.getElementById('message').innerText = message;
});
