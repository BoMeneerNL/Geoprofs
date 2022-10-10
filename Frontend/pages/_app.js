import "../styles/globals.css";
import Navbar from "../components/Navbar";
import { useRouter } from "next/router";
import axios from "axios";
function MyApp({ Component, pageProps }) {
  const router = useRouter();
  if(router.pathname !== "/login" && router.pathname !== "/register"){
    axios.get("",)
  }
  return (
    <>
      <Navbar />
      <Component {...pageProps} />
    </>
  );
}

export default MyApp;
