import Paper from "@mui/material/Paper";
import Link from "next/link";

export default function Navbar(props) {
  const authtypeid = props.authtypeid;

  return (
    <Paper
      style={{
        fontSize: 18,
        color: "white",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        gap: 35,
      }}
      sx={{ height: 80, backgroundColor: "#000" }}
    >
      {authtypeid >= 2 ? <Link href="/">Personeelsoverzicht</Link> : <></>}
      {authtypeid >= 1 ? <Link href="/verlof">Verlofoverzicht</Link> : <></>}
      <Link href="/verlofAanvragen">Verlof aanvragen</Link>
      {authtypeid > 0 ? <></> : <Link href="/login">Inloggen</Link>}
      {authtypeid >= 2 ? <Link href="/registratie">Registreren</Link> : <></>}
    </Paper>
  );
}
