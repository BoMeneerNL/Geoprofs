import Paper from "@mui/material/Paper";
import Link from "next/link";

export default function Navbar(props) {
  const authtype = props.authtype;

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
      {authtype.medewerkerType >= 2 ? (
        <Link href="/">Personeelsoverzicht</Link>
      ) : (
        <></>
      )}
      {authtype.medewerkerType >= 0 ? (
        <Link href="/verlof">Verlofoverzicht</Link>
      ) : (
        <></>
      )}
      <Link href="/verlofAanvragen">Verlof aanvragen</Link>
      {authtype.medewerkerType >= 0 ? (
        <></>
      ) : (
        <Link href="/login">Inloggen</Link>
      )}
      {authtype.medewerkerType >= 2 ? (
        <Link href="/registratie">Registreren</Link>
      ) : (
        <></>
      )}
      {authtype.medewerkerType >= 0 ? (
        <Link href="/logout">Uitloggen</Link>
      ) : (
        <></>
      )}
    </Paper>
  );
}
