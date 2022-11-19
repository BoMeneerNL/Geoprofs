import React, { useRef, useState, useEffect } from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { useRouter } from "next/router";
import axios from "axios";
import { Checkbox } from "@mui/material";
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";

const theme = createTheme();

export default function Register() {
  const router = useRouter();

  const teams = ["Team 1", "Team 2", "Team 3"];

  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  let [curTeam, setCurTeam] = useState(teams[0]);

  const inputName = useRef();
  const inputPassword = useRef();
  const inputConfirmPassword = useRef();

  const handleSubmit = (event) => {
    event.preventDefault();
    if (
      name.length != 0 &&
      password === confirmPassword &&
      password.length != 0
    ) {
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
      inputName.current.style.border = "1px solid red";
    } else if (
      (name && password.length === 0) ||
      (name && confirmPassword.length === 0)
    ) {
      inputPassword.current.style.border = "1px solid red";
      inputConfirmPassword.current.style.border = "1px solid red";
    } else {
      inputPassword.current.style.border = "1px solid red";
      inputConfirmPassword.current.style.border = "1px solid red";
    }
  };

  return (
    <>
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
              <InputLabel id="select-label">Team</InputLabel>
              <Select
                style={{ width: "100%" }}
                labelId="select-label"
                id="select"
                defaultValue={curTeam}
                onChange={(e) => {
                  console.log(e, curTeam);
                  setCurTeam(e.target.value);
                }}
              >
                {/* <MenuItem key="2" value="2">2</MenuItem>
                <MenuItem key="3" value="3">3</MenuItem> */}

                {teams.map((team) => {
                  console.log(team);
                  return (
                    <MenuItem key={team} value={team}>
                      {team}
                    </MenuItem>
                  );
                })}
              </Select>
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

              <Checkbox defaultChecked />
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
