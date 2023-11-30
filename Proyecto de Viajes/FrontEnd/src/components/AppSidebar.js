import React from 'react'
import { useSelector, useDispatch } from 'react-redux'

import { CSidebar, CSidebarBrand, CSidebarNav, CSidebarToggler } from '@coreui/react'
import CIcon from '@coreui/icons-react'

import { AppSidebarNav } from './AppSidebarNav'

import { logoNegative } from 'src/assets/brand/logo-negative'
import { sygnet } from 'src/assets/brand/sygnet'

import SimpleBar from 'simplebar-react'
import 'simplebar/dist/simplebar.min.css'
import axios from 'axios'
import { useState, useEffect } from 'react'

// sidebar nav config
import navigation from '../_nav'

const AppSidebar = () => {
  const dispatch = useDispatch()
  const unfoldable = useSelector((state) => state.sidebarUnfoldable)
  const sidebarShow = useSelector((state) => state.sidebarShow)


  return (
    <CSidebar
      position="fixed"
      unfoldable={unfoldable}
      visible={sidebarShow}
      onVisibleChange={(visible) => {
        dispatch({ type: 'set', sidebarShow: visible })
      }}
    >
      <CSidebarBrand className="d-none d-md-flex pt-3 pb-3" to="/" style={{backgroundColor: 'rgba(74, 147, 190, 100)'}}>
      <div style={{ width: '100px', height: '100px', overflow: 'hidden', borderRadius: '80%'}}>
                      <img src="https://i.ibb.co/StHd135/logo-1.png" style={{ objectFit: 'cover', width: '100%', height: '100%', borderRadius: '50%' }} alt="LoginImg" />
                    </div>
         
      </CSidebarBrand>
      <CSidebarNav style={{backgroundColor: 'rgba(74, 147, 190, 100)'}}>
        <SimpleBar >
          <AppSidebarNav items={navigation} />
        </SimpleBar>
      </CSidebarNav>
    </CSidebar>
  )
}

export default React.memo(AppSidebar)
