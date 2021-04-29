import React from 'react';
import logoImg from '../../logo.svg'
import{
    Container, 
    Header, 
    LogImg, 
    MenuContainer, 
    MenuItemLink,
    Title 
} from './style';

import {
    MdDashboard,
    MdArrowDownward, 
    MdArrowUpward,
    MdExitToApp
}from 'react-icons/md';

const Aside: React.FC = () =>{
    return(
        <Container>
            <Header>
                <LogImg src={logoImg} alt="My Wallet Logo" />
                <Title>Tarefas</Title>              
            </Header>

            <MenuContainer>
                <MenuItemLink href="/dashboard">
                    <MdDashboard/>
                    Dashboard
                </MenuItemLink>

                <MenuItemLink href="/list/entry-balance">
                    <MdArrowUpward/>
                    Entrance
                </MenuItemLink>

                <MenuItemLink href="/list/exit-balance">
                    <MdArrowDownward/>
                    Exits
                </MenuItemLink>

                <MenuItemLink href="#">
                    <MdExitToApp/>
                    Exit
                </MenuItemLink>

            </MenuContainer>          
        </Container>
    );
}

export default Aside;