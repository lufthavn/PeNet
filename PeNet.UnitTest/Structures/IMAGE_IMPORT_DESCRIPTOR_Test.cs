﻿/***********************************************************************
Copyright 2016 Stefan Hausotte

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeNet.Structures;

namespace PeNet.UnitTest.Structures
{
    [TestClass]
    public class IMAGE_IMPORT_DESCRIPTOR_Test
    {
        private readonly byte[] _rawImportDescriptor =
        {
            0xff, // Junk
            0xff,

            0x00, // OriginalFirstThunk / Characteristics
            0x11,
            0x22,
            0x33,

            0x44, // TimeDateStamp
            0x55,
            0x66,
            0x77,

            0x88, // ForwarderChain
            0x99,
            0xaa,
            0xbb,

            0xcc, // Name
            0xdd,
            0xee,
            0xff,

            0x11, // FirstThunk
            0x22,
            0x33,
            0x44
        };

        [TestMethod]
        public void ImageImportDescriptorConstructorWorks_Test()
        {
            var importDescriptor = new IMAGE_IMPORT_DESCRIPTOR(_rawImportDescriptor, 2);
            Assert.AreEqual((uint) 0x33221100, importDescriptor.OriginalFirstThunk);
            Assert.AreEqual((uint) 0x77665544, importDescriptor.TimeDateStamp);
            Assert.AreEqual((uint) 0xbbaa9988, importDescriptor.ForwarderChain);
            Assert.AreEqual((uint) 0xffeeddcc, importDescriptor.Name);
            Assert.AreEqual((uint) 0x44332211, importDescriptor.FirstThunk);
        }
    }
}