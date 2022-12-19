import { useEffect, useState } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterMoment } from "@mui/x-date-pickers/AdapterMoment";
import { LocalizationProvider } from "@mui/x-date-pickers";
import axios from "axios";
import moment from "moment";
import { useRouter } from "next/router";

export default function VerlofAanvraag(props) {
  const router = useRouter();
  const [van, setVan] = useState(null);
  const [vanTimestamp, setVanTimestamp] = useState(0);
  const [tot, setTot] = useState(null);
  const [totTimestamp, setTotTimestamp] = useState(0);
  const [reden, setReden] = useState("");

  function vraagVerlofAan() {
    axios
      .put("http://localhost:11738/Verlof", {
        teamID: props.auth["teamID"],
        medewerkerId: props.auth["medewerkerID"],
        van: vanTimestamp,
        tot: totTimestamp,
        status: 1,
        reden: reden,
      })
      .then(() => {
        router.push("/verlof");
      });
  }
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
            <TextField
              margin="normal"
              required
              fullWidth
              id="reden"
              name="reden"
              label="Reden"
              sx={{marginTop: 0}}
              value={reden}
              onChange={(e) => setReden(e.target.value)}
            />
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
