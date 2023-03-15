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
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";

const theme = createTheme();

export default function Register() {
  const router = useRouter();

  const [hideMedewerker, setHideMedewerker] = useState(false);

  const RegistreerMedewerker = () => {
    const medewerkerType = ["0: Medewerker", "1: Teamleider", "2: Directie"];

    const [allTeams, setAllTeams] = useState([]);
    const [currentTeam, setCurrentTeam] = useState("");
    const [name, setName] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    let [curMedewerkerType, setCurMedewerkerType] = useState(medewerkerType[0]);

    const inputName = useRef();
    const inputPassword = useRef();
    const inputConfirmPassword = useRef();

    useEffect(() => {
      axios
        .get(`http://localhost:11738/Teams/`)
        .then(({ data }) => {
          setAllTeams(data);
          setCurrentTeam(data[0]);
        })
        .then(() => {})
        .catch(() => {});
    }, []);

    const handleSubmit = (event) => {
      event.preventDefault();

      if (
        name.length !== 0 &&
        password === confirmPassword &&
        password.length !== 0
      ) {
        const data = new FormData(event.currentTarget);
        axios
          .put("http://localhost:11738/Medewerker", {
            isAdmin: false,
            Naam: data.get("name"),
            Wachtwoord: data.get("password"),
            MedewerkerType: curMedewerkerType.charAt(0),
            TeamID: currentTeam.id,
          })
          .then(() => {
            router
              .push("/")
              .then(() => {})
              .catch(() => {});
          })
          .catch(() => {});
      } else if (name.length === 0) {
        inputName.current.style.border = "1px solid red";
      } else {
        inputPassword.current.style.border = "1px solid red";
        inputConfirmPassword.current.style.border = "1px solid red";
      }
    };

    return (
      <>
        <Typography component="h1" variant="h5">
          Registreer medewerker
        </Typography>
        <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
          <InputLabel id="select-label">Medewerker type</InputLabel>
          <Select
            style={{ width: "100%" }}
            labelId="select-label"
            id="select"
            defaultValue={curMedewerkerType}
            onChange={(e) => {
              setCurMedewerkerType(e.target.value);
            }}
          >
            {medewerkerType.map((medewerker) => {
              return (
                <MenuItem key={medewerker} value={medewerker}>
                  {medewerker}
                </MenuItem>
              );
            })}
          </Select>
          <InputLabel id="select-label">Selecteer team</InputLabel>
          <Select
            style={{ width: "100%" }}
            labelId="select-label"
            id="select"
            defaultValue=""
            onChange={(e) => {
              setCurrentTeam(e.target.value);
            }}
          >
            {allTeams.map((team) => {
              return (
                <MenuItem key={team.id} value={team}>
                  {team.naam}
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
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Registreren
          </Button>
        </Box>
      </>
    );
  };

  const RegistreerTeam = () => {
    const [teamNaam, setTeamNaam] = useState("");

    const handleSubmit = (event) => {
      event.preventDefault();

      if (teamNaam.length !== 0) {
        axios
          .post(`http://localhost:11738/addteam/${teamNaam}`)
          .then((response) => {
            console.log(response);
            window.location.reload();
          })
          .catch((e) => {
            console.log(e);
          });
      }
    };

    return (
      <>
        <Typography component="h1" variant="h5">
          Registreer team
        </Typography>
        <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            type="text"
            id="teamNaam"
            name="teamNaam"
            label="Team naam"
            value={teamNaam}
            onChange={(e) => setTeamNaam(e.target.value)}
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
      </>
    );
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
            <Box
              sx={{
                display: "flex",
                gap: "20px",
                marginBottom: "24px",
                background: "#eaeaea",
                padding: "11px",
                borderRadius: "20px",
              }}
            >
              <Button
                onClick={() => {
                  setHideMedewerker(false);
                }}
              >
                Registreer medewerker
              </Button>
              <Button
                onClick={() => {
                  setHideMedewerker(true);
                }}
              >
                Registreer team
              </Button>
            </Box>
            {hideMedewerker ? <RegistreerTeam /> : <RegistreerMedewerker />}
          </Box>
        </Container>
      </ThemeProvider>
    </>
  );
}
