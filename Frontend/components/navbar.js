import Paper from "@mui/material/Paper";
import {useRouter} from "next/router";

export default function Navbar() {
  const router = useRouter();
  function goto(gotolink){
    router.push(gotolink);
  }
  return (
    <Paper
      style={{fontSize: 18, color: "white", display: "flex", alignItems: "center", justifyContent: "center", gap: 35}}
      sx={{height: 80, backgroundColor: "#000"}}>
      <a onClick={() => router.push("/")}>Personeelsoverzicht</a>
      <a onClick={() => goto("/verlof")}>Verlofoverzicht</a>
      <a onClick={() => goto("/verlofAanvragen")}>Verlof aanvragen</a>
      <a onClick={()=>goto("/login")}>Inloggen</a>
    </Paper>
  );
}