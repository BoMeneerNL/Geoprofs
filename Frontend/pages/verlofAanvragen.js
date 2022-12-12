import { useEffect, useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterMoment } from "@mui/x-date-pickers/AdapterMoment";
import { LocalizationProvider } from "@mui/x-date-pickers";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import axios from "axios";
import moment from "moment";
import { useRouter } from "next/router";

function getAllMedewerkersNames() {
  let datacollector = [];
  let datafield = [];
  axios.get("http://localhost:11738/Medewerker").then((response) => {
    datacollector = response.data;
    datacollector.map((row, key) => {
      datafield.push(
        <MenuItem key={key} value={row.medewerkerID}>
          {row.naam}
        </MenuItem>
      );
    });
  });
  return datafield;
}

export default function VerlofAanvraag() {
  const router = useRouter();
  const [van, setVan] = useState(null);
  const [vanTimestamp, setVanTimestamp] = useState(0);
  const [tot, setTot] = useState(null);
  const [totTimestamp, setTotTimestamp] = useState(0);
  let [curUser, setCurUser] = useState(0);

  const [users, setUsers] = useState([]);

  console.log("wat is user", users);
  function vraagVerlofAan() {
    axios
      .put("http://localhost:11738/Verlof", {
        medewerkerId: curUser,
        // teamId: 1,
        van: vanTimestamp,
        tot: totTimestamp,
        status: 1,
        reden: null,
      })
      .then(() => {
        router.push("/verlof");
      });
  }

  function test() {
    console.log("test", users);
    console.log("curUser", curUser);
  }

  useEffect(() => {
    setUsers(getAllMedewerkersNames());
  }, []);

  useEffect(() => {
    setVanTimestamp(moment(van).unix());
  }, [van]);
  useEffect(() => {
    setTotTimestamp(moment(tot).unix());
  }, [tot]);
  return (
    <>
      <Container component="main" maxWidth="xs">
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography component="h1" variant="h5">
            Verlof aanvragen
          </Typography>
          <Box
            component="form"
            noValidate
            sx={{
              mt: 1,
              display: "flex",
              flexDirection: "column",
              gap: 2,
              width: 400,
            }}
          >
            <LocalizationProvider
              dateAdapter={AdapterMoment}
              adapterLocale={"de"}
            >
              <InputLabel id="select-label">Medewerker</InputLabel>
              <Select
                labelId="select-label"
                id="select"
                value={curUser}
                onChange={(e) => {
                  setCurUser(e.target.value);
                }}
                onClick={(e) => {
                  test();
                }}
              >
                {users}
              </Select>
              <DatePicker
                disablePast
                label="Van"
                value={van}
                onChange={(value) => {
                  setVan(value);
                }}
                renderInput={(params) => <TextField {...params} />}
              />
              <DatePicker
                disablePast
                label="Tot"
                value={tot}
                onChange={(value) => {
                  setTot(value);
                }}
                renderInput={(params) => <TextField {...params} />}
              />
            </LocalizationProvider>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              onClick={(e) => {
                e.preventDefault();
                vraagVerlofAan();
              }}
            >
              Vraag verlof aan
            </Button>
          </Box>
        </Box>
      </Container>
    </>
  );
}
