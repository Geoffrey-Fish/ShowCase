// Copyright 2023 QMK
// SPDX-License-Identifier: GPL-2.0-or-later

/*******************************************************************************
  88888888888 888      d8b                .d888 d8b 888               d8b
      888     888      Y8P               d88P"  Y8P 888               Y8P
      888     888                        888        888
      888     88888b.  888 .d8888b       888888 888 888  .d88b.       888 .d8888b
      888     888 "88b 888 88K           888    888 888 d8P  Y8b      888 88K
      888     888  888 888 "Y8888b.      888    888 888 88888888      888 "Y8888b.
      888     888  888 888      X88      888    888 888 Y8b.          888      X88
      888     888  888 888  88888P'      888    888 888  "Y8888       888  88888P'
                                                        888                 888
                                                        888                 888
                                                        888                 888
     .d88b.   .d88b.  88888b.   .d88b.  888d888 8888b.  888888 .d88b.   .d88888
    d88P"88b d8P  Y8b 888 "88b d8P  Y8b 888P"      "88b 888   d8P  Y8b d88" 888
    888  888 88888888 888  888 88888888 888    .d888888 888   88888888 888  888
    Y88b 888 Y8b.     888  888 Y8b.     888    888  888 Y88b. Y8b.     Y88b 888
     "Y88888  "Y8888  888  888  "Y8888  888    "Y888888  "Y888 "Y8888   "Y88888
         888
    Y8b d88P
     "Y88P"
*******************************************************************************/

#pragma once

#ifndef DEBOUNCE
#    define DEBOUNCE 5
#endif // DEBOUNCE

#ifndef DIODE_DIRECTION
#    define DIODE_DIRECTION COL2ROW
#endif // DIODE_DIRECTION

#ifndef SOFT_SERIAL_PIN
#    define SOFT_SERIAL_PIN D2
#endif // SOFT_SERIAL_PIN

#ifndef TAP_CODE_DELAY
#    define TAP_CODE_DELAY 10
#endif // TAP_CODE_DELAY

#ifndef TAPPING_TERM
#    define TAPPING_TERM 100
#endif // TAPPING_TERM

#ifndef PRODUCT_ID
#    define PRODUCT_ID 0x0287
#endif // PRODUCT_ID

#ifndef VENDOR_ID
#    define VENDOR_ID 0xFC32
#endif // VENDOR_ID

#ifndef PRODUCT
#    define PRODUCT "Sofle"
#endif // PRODUCT

#ifndef MANUFACTURER
#    define MANUFACTURER "JosefAdamcik"
#endif // MANUFACTURER

#ifndef DEVICE_VER
#    define DEVICE_VER 0x0001
#endif // DEVICE_VER

#ifndef MATRIX_COLS
#    define MATRIX_COLS 6
#endif // MATRIX_COLS

#ifndef MATRIX_ROWS
#    define MATRIX_ROWS 10
#endif // MATRIX_ROWS

#ifndef MATRIX_COL_PINS
#    define MATRIX_COL_PINS { F6, F7, B1, B3, B2, B6 }
#endif // MATRIX_COL_PINS

#ifndef MATRIX_ROW_PINS
#    define MATRIX_ROW_PINS { C6, D7, E6, B4, B5 }
#endif // MATRIX_ROW_PINS

#ifndef ENCODERS_PAD_A
#    define ENCODERS_PAD_A { F5 }
#endif // ENCODERS_PAD_A

#ifndef ENCODERS_PAD_B
#    define ENCODERS_PAD_B { F4 }
#endif // ENCODERS_PAD_B

#ifndef ENCODER_RESOLUTION
#    define ENCODER_RESOLUTION 2
#endif // ENCODER_RESOLUTION

#ifndef ENCODERS_PAD_A_RIGHT
#    define ENCODERS_PAD_A_RIGHT { F4 }
#endif // ENCODERS_PAD_A_RIGHT

#ifndef ENCODERS_PAD_B_RIGHT
#    define ENCODERS_PAD_B_RIGHT { F5 }
#endif // ENCODERS_PAD_B_RIGHT

#ifndef ENCODER_RESOLUTION_RIGHT
#    define ENCODER_RESOLUTION_RIGHT 2
#endif // ENCODER_RESOLUTION_RIGHT
