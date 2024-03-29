import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';

import LoginScreen from './Pages/Login';


const AuthStack = createStackNavigator({
    SignIn: { screen: SignInScreen },
});


const TabBarComponent = props => <BottomTabBar {...props} />;

const MainNavigator = createBottomTabNavigator({
    //'Main' e 'Profile' são rotas criadas e nomeadas nesta função
    Login: { screen: LoginScreen, },
},
    {
        initialRouteName: 'Login',
        tabBarOptions: {
            showLabel: false,
            showIcon: true,
            activeBackgroundColor: '#9900e6',
            inactiveBackgroundColor: '#b727ff',
            style: {
                width: '100%',
                height: 50
            }
        }
    },
);

export default createAppContainer(createSwitchNavigator(
    //Rotas paralelas
    {
        MainNavigator,
        AuthStack,
    },
    //Rota por onde começa
    {
        initialRouteName: 'AuthStack'
    }
));