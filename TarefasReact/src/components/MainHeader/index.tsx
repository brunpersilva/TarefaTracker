import React, { useMemo, useState } from 'react';

import Toggle from '../Toggle';
import emojis from '../../utils/emoji';


import { 
    Container, 
    Profile, 
    Welcome, 
    UserName, 
}  from './style';


const MainHeader: React.FC = () => {


    const emoji = useMemo(() => {
        const indice = Math.floor(Math.random() * emojis.length);
        return emojis[indice];
    },[]);

    return (
        <Container>
            <Toggle/>

            <Profile>
                <Welcome>Olá, {emoji}</Welcome>
                <UserName>User</UserName>
            </Profile>
        </Container>
    );
}

export default MainHeader;