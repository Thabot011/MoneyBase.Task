let sessionId = null;
let interval = null;

async function startChat(chatTitle) {
    const res = await fetch('api/chats', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Title: chatTitle })
    });
    const data = await res.json();
    if (res.status != 200) {
        alert('Queue full — try again later.');
        return;
    }
    sessionId = data;
    document.getElementById('status').textContent = `Session started: ${sessionId}`;
    startPolling();
}

function startPolling() {
    if (interval) clearInterval(interval);
    interval = setInterval(async () => {
        if (!sessionId) return;
        const res = await fetch(`api/chats/${sessionId}/status`);
        if (!res.ok) return;
    }, 1000); // 1 second
}


document.getElementById('startBtn').addEventListener('click', () => {
    const chatTitle = document.getElementById('chatTitle').value || 'test';
    startChat(chatTitle);
});

