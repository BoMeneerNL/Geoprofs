import * as React from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Navbar from "../components/navbar";
import { useRouter } from "next/router";
import axios from "axios";

const theme = createTheme();

export default function Register() {
  const router = useRouter();

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      name: data.get("name"),
      password: data.get("password"),
    });
    axios
      .put("http://localhost:11738/Medewerker", {
        isAdmin: false,
        naam: data.get("name"),
        wachtwoord: data.get("password"),
      })
      .then(() => {
        router.push("/");
      });
  };

  return (
    <>
      <Navbar />
      <ThemeProvider theme={theme}>
        <Container component="main" maxWidth="xs">
          <CssBaseline />
          <Box
            sx={{
              marginTop: 8,
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
            }}
          >
            <Typography component="h1" variant="h5">
              Registreren
            </Typography>
            <Box
              component="form"
              onSubmit={handleSubmit}
              noValidate
              sx={{ mt: 1 }}
            >
              <TextField
                margin="normal"
                required
                fullWidth
                id="name"
                name="name"
                label="Naam"
              />
              <TextField
                margin="normal"
                required
                fullWidth
                id="password"
                name="password"
                label="Wachtwoord"
                type="password"
                autocomplete="current-password"
              />
              <TextField
                margin="normal"
                required
                fullWidth
                id="repeat-password"
                name="repeat-password"
                label="Herhaal wachtwoord"
                type="password"
                autocomplete="current-password"
              />
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                Registreren
              </Button>
            </Box>
          </Box>
        </Container>
      </ThemeProvider>
    </>
  );
}