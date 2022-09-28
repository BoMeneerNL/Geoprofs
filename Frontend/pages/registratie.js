import React, { useRef, useState } from "react";
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

  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const inputName = useRef()
  const inputPassword = useRef()
  const inputConfirmPassword = useRef()

  const handleSubmit = (event) => {
    event.preventDefault();
    if (name && password === confirmPassword) {
      const data = new FormData(event.currentTarget);
      axios
        .put("http://localhost:11738/Medewerker", {
          isAdmin: false,
          naam: data.get("name"),
          wachtwoord: data.get("password"),
        })
        .then(() => {
          router.push("/");
        });
    } else if (name.length === 0) {
      console.log("voer naam in")
      inputName.current.style.border="1px solid red";
    } else {
      console.log("foutieve wachtwoord")
      inputPassword.current.style.border="1px solid red";
      inputConfirmPassword.current.style.border="1px solid red";
    }
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
                value={name}
                onChange={(e) => setName(e.target.value)}
                ref={inputName}
              />
              <TextField
                margin="normal"
                required
                fullWidth
                id="password"
                name="password"
                label="Wachtwoord"
                type="password"
                autoComplete="current-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                ref={inputPassword}
              />
              <TextField
                margin="normal"
                required
                fullWidth
                id="repeat-password"
                name="repeat-password"
                label="Herhaal wachtwoord"
                type="password"
                autoComplete="current-password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                ref={inputConfirmPassword}
              />
              {}
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
