import Paper from "@mui/material/Paper";
import { useRouter } from "next/router";
import Link from "next/link";

export default function Navbar() {
  const router = useRouter();
  function goto(gotolink) {
    router.push(gotolink);
  }
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
      <Link href="/">
        <a>Personeelsoverzicht</a>
      </Link>
      <Link href="/verlof">
        <a>Verlofoverzicht</a>
      </Link>
      <Link href="/verlofAanvragen">
        <a>Verlof aanvragen</a>
      </Link>
      <Link href="/login">
        <a>Inloggen</a>
      </Link>
      <Link href="/registratie">
        <a>Registreren</a>
      </Link>
    </Paper>
  );
}
