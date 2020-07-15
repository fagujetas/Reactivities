import React from 'react'
import { Menu, Container, Button } from 'semantic-ui-react'

interface IProps {
    openCreateForm: () => void;
}

export const NavBar: React.FC<IProps> = ({openCreateForm}) => {
    return (
        <Container>
            <Menu fixed='top' inverted>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: 10}} />
                    Reactivities
                </Menu.Item>
                <Menu.Item name='Activities' />
                <Menu.Item>
                    <Button onClick={openCreateForm} positive content='Create Activity' />
                </Menu.Item>
            </Menu>
        </Container>
    )
}
