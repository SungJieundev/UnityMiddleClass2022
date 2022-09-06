const ws = require('ws');

const wss = new ws.Server({port:8080});

wss.on("listening", () => {
    console.log("서버가 열렸습니다");
});

wss.on("connection", ()=>{
    console.log("클라이언트가 접속했습니다.")
});

