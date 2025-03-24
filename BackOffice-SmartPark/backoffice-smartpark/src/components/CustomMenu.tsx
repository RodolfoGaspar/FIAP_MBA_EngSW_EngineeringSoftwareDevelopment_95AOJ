import { Menu } from "react-admin";
import LocalParkingIcon from "@mui/icons-material/LocalParking";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";

const CustomMenu = (props: any) => (
  <Menu {...props}>
    <Menu.Item
      to="/vagas"
      primaryText="Vagas"
      leftIcon={<LocalParkingIcon />}
      onClick={props.onMenuClick}
    />
    <Menu.Item
      to="/pagamentos"
      primaryText="Pagamentos"
      leftIcon={<AttachMoneyIcon />}
      onClick={props.onMenuClick}
    />
  </Menu>
);

export default CustomMenu;
